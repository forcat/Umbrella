using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Umbrella.Database.BLL;
using Umbrella.Model;

namespace UmbrellaConsole.Controllers
{
    [RoutePrefix("api/UmbrellaDevice")]
    public class UmbrellaDeviceController : ApiController
    {
        private UmbrellaDeviceBLL bll = new UmbrellaDeviceBLL();

        public IEnumerable<UmbrellaDevice> Get()
        {
            return bll.FindAll();
        }

        public UmbrellaDevice Get(string id)
        {
            return bll.FindByID(id);
        }

        // POST api/values
        public void Post(UmbrellaDevice model)
        {
            model.DeviceId = Guid.NewGuid().ToString();
            bll.Insert(model);
        }

        // PUT api/values/5
        public void Put(string id, UmbrellaDevice model)
        {
            bll.Update(model, id);
        }

        // DELETE api/values/5
        public void Delete(string id)
        {
            bll.Delete(id);
        }
    }
}
