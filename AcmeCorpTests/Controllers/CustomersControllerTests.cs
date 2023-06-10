using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace AcmeCorp.Controllers.Tests
{
    public class Token
    {
        public string token { get; set; }
    }
    [TestClass()]
    public class CustomersControllerTests
    {

        private HttpClient _client;
        private string _custometEndpoint = "https://localhost:7164/Customers";
        private string _authoEndpoint = "https://localhost:7164/Autho";


        [TestInitialize]
        public void Setup()
        {
            _client = new HttpClient();
        }

        private Token GetToken()
        {
            var authoReq = new HttpRequestMessage(HttpMethod.Get, _authoEndpoint);
            var _authoresult = _client.SendAsync(authoReq).Result;

            var _data = _authoresult.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<Token>(_data);
        }
        [TestMethod()]
        public void GetCustomersTest()
        {
           
            Token token = this.GetToken();
            Assert.IsNotNull(token);
            var req = new HttpRequestMessage(HttpMethod.Get, _custometEndpoint);
            req.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.token);
            var res = _client.SendAsync(req).Result;
            Assert.AreEqual(HttpStatusCode.OK, res.StatusCode);
        }

        [TestMethod()]
        public void GetCustomerByIdTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateCustomerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCustomerTest()
        {
            Assert.Fail();
        }
    }
}