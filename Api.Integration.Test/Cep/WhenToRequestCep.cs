using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.County;
using Newtonsoft.Json;
using Xunit;

namespace Api.Integration.Test.County
{
    public class WhenToRequestCep : BaseIntegration
    {
        private string _cep { get; set; }
        private string _logradouro { get; set; }
        private string _numero { get; set; }
        private Guid _countyId { get; set; }

        [Fact]
        public async Task ItIsPossibleToRunCepCrud() {
            await AddToken();
            var countyDto = new CountyDtoCreate()
            {
                Name = Faker.Address.City(),
                CodeIBGE = Faker.RandomNumber.Next(10000000, 99999999),
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };
            var responseCounty = await PostJsonAsync(countyDto, $"{hostApi}/counties", client);
            var postResultCounty = await responseCounty.Content.ReadAsStringAsync();
            var recordPostCounty = JsonConvert.DeserializeObject<CountyDtoCreateResult>(postResultCounty);


            _cep = Faker.Address.ZipCode();
            _logradouro = Faker.Address.StreetAddress();
            _numero = Faker.RandomNumber.Next(1, 99999).ToString();
            _countyId = recordPostCounty.Id;

            var cepDto = new CepDtoCreate()
            {
                Cep = _cep,
                Logradouro = _logradouro,
                Numero = _numero,
                CountyId = _countyId
            };

            // Post
            var response = await PostJsonAsync(cepDto, $"{hostApi}/ceps", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var recordPost = JsonConvert.DeserializeObject<CepDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_cep, recordPost.Cep);
            Assert.Equal(_logradouro, recordPost.Logradouro);
            Assert.Equal(_numero, recordPost.Numero);
            Assert.Equal(_countyId, recordPost.CountyId);
            Assert.True(recordPost.Id != default(Guid));

            // Get All
            response = await client.GetAsync($"{hostApi}/ceps");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var jsonResult = await response.Content.ReadAsStringAsync();
            var listFromJson = JsonConvert.DeserializeObject<IEnumerable<CepDto>>(jsonResult);
            Assert.NotNull(listFromJson);
            Assert.True(listFromJson.Count()>0);
            Assert.True(listFromJson.Where(r => r.Id ==  recordPost.Id).Count() == 1);

            // Put
            var updateCepDto = new CepDtoUpdate()
            {
                Id = recordPost.Id,
                Cep = Faker.Address.ZipCode(),
                Logradouro = Faker.Address.StreetAddress(),
                Numero = Faker.RandomNumber.Next(1, 99999).ToString(),
                CountyId = recordPostCounty.Id,
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateCepDto),
                                    System.Text.Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}/ceps", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordUpdate = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

            Assert.Equal(updateCepDto.Id, recordUpdate.Id);
            Assert.NotEqual(recordPost.Cep, recordUpdate.Cep);
            Assert.NotEqual(recordPost.Logradouro, recordUpdate.Logradouro);
            Assert.NotEqual(recordPost.Numero, recordUpdate.Numero);
            Assert.Equal(recordPost.CountyId, recordUpdate.CountyId);

            // Get By Id
            response = await client.GetAsync($"{hostApi}/ceps/{recordUpdate.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var recordSelected = JsonConvert.DeserializeObject<CepDto>(jsonResult);

            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Cep, recordUpdate.Cep);
            Assert.Equal(recordSelected.Logradouro, recordUpdate.Logradouro);
            Assert.Equal(recordSelected.Numero, recordUpdate.Numero);
            Assert.Equal(recordSelected.CountyId, recordUpdate.CountyId);

            // findByCep
            response = await client.GetAsync($"{hostApi}/ceps/findByCep/{recordUpdate.Cep}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            jsonResult = await response.Content.ReadAsStringAsync();
            recordSelected = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(recordSelected);
            Assert.Equal(recordSelected.Id, recordUpdate.Id);
            Assert.Equal(recordSelected.Cep, recordUpdate.Cep);
            Assert.Equal(recordSelected.Logradouro, recordUpdate.Logradouro);
            Assert.Equal(recordSelected.Numero, recordUpdate.Numero);
            Assert.Equal(recordSelected.CountyId, recordUpdate.CountyId);

             // Delete
            response = await client.DeleteAsync($"{hostApi}/ceps/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            // Get By Id After Delete
            response = await client.GetAsync($"{hostApi}/ceps/{recordUpdate.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
       }
    }
}