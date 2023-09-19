using FluentAssertions;
using Moq;
using TrialTask.Notes.Application.Notes.CommandHandlers;
using TrialTask.Notes.Application.Notes.Commands;
using TrialTask.Notes.Application.Notes.Queries;
using TrialTask.Notes.Application.Notes.QueryHandlers;
using TrialTask.Notes.Domain.Entities.Notes;
using TrialTask.Notes.Domain.Repositories;

namespace TrialTask.Notes.Tests
{
    public class NoteHandlerTests
    {
        [Fact]
        public async Task CreateNoteCommandHandler_Should_Create_Note()
        {
            // Arrange
            var createRequest = new CreateNote(1, "Test Title", "Test Text", false);
            var noteRepositoryMock = new Mock<INoteRepository>();
            var handler = new CreateNoteHandler(noteRepositoryMock.Object);
            noteRepositoryMock.Setup(repo => repo.CreateNoteAsync(It.IsAny<Note>()))
                             .ReturnsAsync(1); 

            // Act
            var result = await handler.Handle(createRequest, CancellationToken.None);

            // Assert
            result.Should().Be(1);
        }

        [Fact]
        public async Task GetNoteQueryHandler_Should_Return_Note()
        {
            // Arrange
            var noteId = 1; 
            var getNoteQuery = new GetNote(noteId);
            var noteRepositoryMock = new Mock<INoteRepository>();
            var handler = new GetNoteHandler(noteRepositoryMock.Object);
            noteRepositoryMock.Setup(repo => repo.GetByIdNoteAsync(noteId))
                             .ReturnsAsync(new Note { Id = noteId, Title = "Test Title", Text = "Test Text" });

            // Act
            var result = await handler.Handle(getNoteQuery, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(new { Id = noteId, Title = "Test Title", Text = "Test Text" });
        }

        [Fact]
        public async Task UpdateNoteCommandHandler_Should_Update_Note()
        {
            // Arrange
            var noteId = 1; 
            var updateRequest = new UpdateNote(noteId, "Updated Title", "Updated Text");
            var existingNote = new Note { Id = noteId, Title = "Test Title", Text = "Test Text" };
            var noteRepositoryMock = new Mock<INoteRepository>();
            var handler = new UpdateNoteHandler(noteRepositoryMock.Object);
            noteRepositoryMock.Setup(repo => repo.GetByIdNoteAsync(noteId))
                .ReturnsAsync(existingNote);
            noteRepositoryMock.Setup(repo => repo.UpdateNoteAsync(It.IsAny<Note>()))
                .ReturnsAsync(existingNote); 

            // Act
            var updatedNote = await handler.Handle(updateRequest, CancellationToken.None);

            // Assert
            updatedNote.Should().NotBeNull();
            updatedNote.Id.Should().Be(noteId);
            updatedNote.Title.Should().Be("Updated Title");
            updatedNote.Text.Should().Be("Updated Text");
        }

        [Fact]
        public async Task DeleteNoteCommandHandler_Should_Delete_Note()
        {
            // Arrange
            var noteId = 1; 
            var deleteRequest = new DeleteNote(noteId);
            var noteRepositoryMock = new Mock<INoteRepository>();
            var handler = new DeleteNoteHandler(noteRepositoryMock.Object);
            noteRepositoryMock.Setup(repo => repo.GetByIdNoteAsync(noteId))
                .ReturnsAsync(new Note { Id = noteId, Title = "Test Title", Text = "Test Text" });

            // Act
            await handler.Handle(deleteRequest, CancellationToken.None);
            var deletedNote = await noteRepositoryMock.Object.GetByIdNoteAsync(noteId);

            // Assert
            noteRepositoryMock.Verify(repo => repo.DeleteNoteAsync(deletedNote), Times.Once()); 
        }

        [Fact]
        public async Task GetAllNotesQueryHandler_Should_Return_All_Notes()
        {
            // Arrange
            var notes = new List<Note>
        {
            new Note { Id = 1, Title = "Title 1", Text = "Text 1" },
            new Note { Id = 2, Title = "Title 2", Text = "Text 2" }
        };
            var getAllRequest = new GetAllNotes();
            var noteRepositoryMock = new Mock<INoteRepository>();
            var handler = new GetAllNotesHandler(noteRepositoryMock.Object);
            noteRepositoryMock.Setup(repo => repo.GetAllNotesAsync())
                             .ReturnsAsync(notes);

            // Act
            var result = await handler.Handle(getAllRequest, CancellationToken.None);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
        }
    }
}