using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecnoMoto.Models;

namespace TecnoMoto.ViewModels
{
    public class UserViewModel
    {

        public bool isExist()
        {
            try
            {
                using (Db_TecnoMotos db = new Db_TecnoMotos())
                {
                    var client = db.clients.FirstOrDefault();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
