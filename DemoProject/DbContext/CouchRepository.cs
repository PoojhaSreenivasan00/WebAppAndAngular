/*using DemoProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.DbContext
{
    public class CouchRepository : ICouchRepository
    {
        private readonly string _couchDbUrl;
        private readonly string _couchDbName;
        private readonly string _couchDbUser;
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _clientFactory;
        public CouchRepository(IConfiguration config, IHttpClientFactory clientFactory)
        {
            _config = config;
            _clientFactory = clientFactory;
            _couchDbUrl = this._config["CouchDB:URL"];
            _couchDbName = this._config["CouchDB:Name"];



        }
        public IActionResult AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public IActionResult DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult GetAllUser()
        {
            throw new NotImplementedException();
        }

        public IActionResult GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}*/
