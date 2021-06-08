using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.County;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.County
{
    public class WhenToRequestCounty : BaseIntegration
    {
        private string _name { get; set; }
        private int _codeIBGE { get; set; }
        private Guid _ufId { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunUserCrud() {
            await AddToken();
            _name = Faker.Address.City();
            _codeIBGE = Faker.RandomNumber.Next(10000000, 99999999);
            _ufId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6");

            var countyDto = new CountyDtoCreate()
            {
                Name = _name,
                CodeIBGE = _codeIBGE,
                UfId = _ufId
            };

            // Post
            var response = await PostJsonAsync(countyDto, $"{hostApi}/counties", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<CountyDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, recordPost.Name);
            Assert.Equal(_codeIBGE, recordPost.CodeIBGE);
            Assert.Equal(_ufId, recordPost.UfId);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/counties");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<CountyDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Put
            var updateCountyDto = new CountyDtoUpdate()
            {
                Id = recordPost.Id,
                Name = Faker.Address.City(),
                CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = new Guid("971dcb34-86ea-4f92-989d-064f749e23c9")
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateCountyDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/counties", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<CountyDtoUpdateResult>(jsonResult);

            Assert.Equal(updateCountyDto.Id, recordUpdate.Id);
            Assert.NotEqual(recordPost.Name, recordUpdate.Name);
            Assert.NotEqual(recordPost.CodeIBGE, recordUpdate.CodeIBGE);
            Assert.NotEqual(recordPost.UfId, recordUpdate.UfId);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/counties/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<CountyDto>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Name, recordUpdate.Name);
            Assert.Equal(recordSelected.CodeIBGE, recordUpdate.CodeIBGE);
            Assert.Equal(recordSelected.UfId, recordUpdate.UfId);

            // findByName
            response = await client.GetAsync($"{hostApi}/counties/findByName/{recordUpdate.Name}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<CountyDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

            // findByName
            response = await client.GetAsync($"{hostApi}/counties/findByIBGE/{recordUpdate.CodeIBGE}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            recordSelected = JsonConvert.DeserializeObject<CountyDto>(jsonResult);
            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Name, recordUpdate.Name);
            Assert.Equal(recordSelected.CodeIBGE, recordUpdate.CodeIBGE);
            Assert.Equal(recordSelected.UfId, recordUpdate.UfId);

             // Delete
            response = await client.DeleteAsync($"{hostApi}/counties/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/counties/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

       }
    }
}