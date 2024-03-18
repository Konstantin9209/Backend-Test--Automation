using NUnit.Framework;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using Eventmi.Core.Models.Event;
using Microsoft.EntityFrameworkCore;
using Eventmi.Infrastructure.Data.Contexts;
using System.Linq;

namespace Eventmi.Tests
{
    public class Tests
    {
        private RestClient _client;
        private string _baseUrl = "https://localhost:7236/";

        [SetUp]
        public void Setup()
        {
            _client = new RestClient(_baseUrl);
        }

        [Test]
        public void GetAllEvents_ReturnsSuccessStatusCode()
        {
            var request = new RestRequest("/Event/All", Method.Get);

            var response = _client.Execute(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_GetRequestReturnsAddView()
        {
            var request = new RestRequest("/Event/Add", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_PostRequest_AddsNewEventAddRedirects()
        {
            var input = new EventFormModel()
            {
                Name = "Soft Uni Conf",
                Place = "Soft Uni",
                Start = new DateTime(2024, 12, 12, 12, 0, 0),
                End = new DateTime(2024, 12, 12, 16, 0, 0)
            };

            var request = new RestRequest("/Event/Add", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Name", input.Name);
            request.AddParameter("Place", input.Place);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Add_PostRequest_RedirectsIfDataIsInvalid()
        {
            var input = new EventFormModel()
            {
                Name = "",
                Place = "",
                Start = new DateTime(2024, 12, 12, 12, 0, 0),
                End = new DateTime(2024, 12, 12, 16, 0, 0)
            };
            var request = new RestRequest("/Event/Add", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("Name", input.Name);
            request.AddParameter("Place", input.Place);
            request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
            request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));
            var response = await _client.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Details_GetRequest_ShouldReturnDetailedView()
        {
            var eventId = 1;
            var request = new RestRequest($"/Event/Details/{eventId}", Method.Get);
            var response = await _client.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Details_GetRequest_ShouldReturnNotFoundIfNoIdIsGiven()
        {
            var request = new RestRequest($"/Event/Details/", Method.Get);
            var response = await _client.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public async Task Edit_GetRequest_ShouldReturnEditView()
        {
            var eventId = 1;
            var request = new RestRequest($"/Event/Edit/{eventId}", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public async Task Edit_GetRequest_ShouldReturnNoFoundIfNoIdIsGiven()
        {
            var request = new RestRequest($"/Event/Edit/", Method.Get);

            var response = await _client.ExecuteAsync(request);

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        //[Test]
        //public async Task Edit_PostRequest_ShouldEditAnEvent()
        //{
        //    var eventId = 1;
        //    var dbEvent = GetEventById(eventId);
        //    var input = new EventFormModel()
        //    {
        //        Id = dbEvent.Id,
        //        End = dbEvent.End,
        //        Name = dbEvent.Name,
        //        Place = dbEvent.Place,
        //        Start = dbEvent.Start,
        //    };
        //    var request = new RestRequest("/Event/Edit", Method.Post);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
        //    request.AddParameter("Id", input.Id);
        //    request.AddParameter("Name", input.Name);
        //    request.AddParameter("Place", input.Place);
        //    request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
        //    request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));

        //    var response = await _client.ExecuteAsync(request);

        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        //    var updatedDbEvent = GetEventById(eventId);
        //    Assert.That(updatedDbEvent.Name, Is.EqualTo(input.Name));
        //}

        //[Test]
        //public async Task Edit_WithMismatch_ShouldReturnNotFound()
        //{
        //    var eventId = 1;
        //    var dbEvent = GetEventById(eventId);
        //    var input = new EventFormModel()
        //    {
        //        Id = dbEvent.Id,
        //        End = dbEvent.End,
        //        Name = dbEvent.Name,
        //        Place = dbEvent.Place,
        //        Start = dbEvent.Start,
        //    };
        //    var request = new RestRequest($"/Event/Edit/{dbEvent.Id}", Method.Post);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        //    request.AddParameter("Id", input.Id);
        //    request.AddParameter("Name", input.Name);
        //    request.AddParameter("Place", input.Place);
        //    request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
        //    request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));

        //    var response = await _client.ExecuteAsync(request);
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        //    var updatedDbEvent = GetEventById(eventId);
        //    Assert.That(updatedDbEvent.Name, Is.Not.EqualTo(input.Name));
        //}

        //[Test]
        //public async Task Delete_WithNoId_ShouldReturnNotFound()
        //{
        //    var request = new RestRequest("/Event/Delete/", Method.Post);
        //    var response = await _client.ExecuteAsync(request);
        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        //}

        //[Test]
        //public async Task Delete_WithValidIdShouldReturn_RedirectToAllItems()
        //{
        //    var input = new EventFormModel()
        //    {
        //        Name = "Test Soft Uni Conf",
        //        Place = "Soft Uni",
        //        Start = new DateTime(2024, 12, 12, 12, 0, 0),
        //        End = new DateTime(2024, 12, 12, 16, 0, 0)
        //    };
        //    var request = new RestRequest("/Event/Add", Method.Post);
        //    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

        //    request.AddParameter("Name", input.Name);
        //    request.AddParameter("Place", input.Place);
        //    request.AddParameter("Start", input.Start.ToString("MM/dd/yyyy hh:mm tt"));
        //    request.AddParameter("End", input.End.ToString("MM/dd/yyyy hh:mm tt"));
        //    await _client.ExecuteAsync(request);

        //    var eventInDb = GetEventByName(input.Name);
        //    var eventIdToDelete = eventInDb.Id;

        //    var deleteRequest = new RestRequest($"/Event/Delete/{eventIdToDelete}", Method.Post);

        //    var response = await _client.ExecuteAsync(deleteRequest);

        //    Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Redirect));
        //}

        //private Event GetEventById(int id)
        //{
        //    var options = new DbContextOptionsBuilder<EventmiContext>().UseSqlServer("Server=.;Database=Eventmi;Trusted_Connection=False;UserId=sa;Password=nqmamparolaoshte;").Options;
        //    using var context = new EventmiContext(options);
        //    return context.Events.FirstOrDefault(x => x.Id == id);
        //}

        //private Event GetEventByName(string name)
        //{
        //    var options = new DbContextOptionsBuilder<EventmiContext>().UseSqlServer("Server=.;Database=Eventmi;Trusted_Connection=False;UserId=sa;Password=nqmamparolaoshte;").Options;
        //    using var context = new EventmiContext(options);
        //    return context.Events.FirstOrDefault(x => x.Name == name);
        //}
    }
}
