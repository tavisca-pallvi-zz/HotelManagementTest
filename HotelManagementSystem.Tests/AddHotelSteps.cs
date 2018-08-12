using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
        private List<Hotel> hotelsVerify = new List<Hotel>();


        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }
        [When(@"User calls get all hotels")]
        public void WhenUserCallsGetAllHotels()
        {

            hotelsVerify = HotelsApiCaller.VerifyHotel(hotels);
        }


        [Given(@"User calls AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void GivenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }
       


        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} found in response",name));
        }


        [When(@"User calls GetHotelById '(.*)' api")]
        public void WhenUserCallsGetHotelByIdApi(int id)
        {
            addHotelResponse = HotelsApiCaller.GetHotelById(id);
        }

         

        [Then(@"Hotel with id '(.*)' should be returned in the response")]
        public void ThenHotelWithIdShouldBeReturnedInTheResponse(int id)
        {
            hotel = hotels.Find(htl => htl.Id==id);
            hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response", id));
        }

        [Given(@"User provided valid Id '(.*)' to get hotel details")]
        public void GivenUserProvidedValidIdToGetHotelDetails(int id)
        {
           // hotel = hotels.Find(htl => htl.Id == id);
            hotels = HotelsApiCaller.AddHotel(hotel);
        }


        [Then(@"All added Hotels should be returned in the response")]
        public void ThenAllAddedHotelsShouldBeReturnedInTheResponse()
        {
      
            for (int i = 0; i < hotels.Count; i++)
            {
                hotelsVerify[i].Id.Should().Be(hotels[i].Id);
            } 

        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
    }
}
