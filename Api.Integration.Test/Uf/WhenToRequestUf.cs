using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.Uf
{
    public class WhenToRequestUf : BaseIntegration
    {
        private string _name { get; set; }
        private string _initials { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunUfCrud() {
            await AddToken();
            _name = Faker.Address.StreetAddress();
            _initials = Faker.Address.UsStateAbbr();

            var ufDto = new UfDtoCreate()
            {
                Name = _name,
                Initials = _initials
            };

            // Post
            var response = await PostJsonAsync(ufDto, $"{hostApi}/ufs", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<UfDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_name, recordPost.Name);
            Assert.Equal(_initials, recordPost.Initials);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/ufs");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            var id = listFromJson.Where(r => r.Initials == "SP").FirstOrDefault().Id;
            response = await client.GetAsync($"{hostApi}/ufs/{id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<UfDto>(jsonResult);
            Assert.NotNull(recordSelected);
            Assert.Equal("São Paulo", recordSelected.Name);

            // Put
            var updateUfDto = new UfDtoUpdate()
            {
                Id = recordPost.Id,
                Name = Faker.Address.StreetAddress(),
                Initials = Faker.Address.UsStateAbbr()
            };
            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUfDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/ufs", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<UfDtoUpdateResult>(jsonResult);

            Assert.Equal(updateUfDto.Id, recordUpdate.Id);
            Assert.NotEqual(recordPost.Name, recordUpdate.Name);
            Assert.NotEqual(recordPost.Initials, recordUpdate.Initials);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/ufs/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            recordSelected = JsonConvert.DeserializeObject<UfDto>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Name, recordUpdate.Name);
            Assert.Equal(recordSelected.Initials, recordUpdate.Initials);

            // Delete
            response = await client.DeleteAsync($"{hostApi}/ufs/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/ufs/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);

            // findByName
            response = await client.GetAsync($"{hostApi}/ufs/findByName/a");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            listFromJson = JsonConvert.DeserializeObject<IEnumerable<UfDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);

        }
    }
}