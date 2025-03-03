using BussinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Concrete
{
    public class WriterLoginManager: IWriterLoginService
    {
        IWriterDal _writerDal;

        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetWriter(string mail, string password)
        {
            var result = _writerDal.List(x => x.WriterMail == mail);
            return result.FirstOrDefault(x => BCrypt.Net.BCrypt.Verify(password, x.WriterPassword));

        }
    }
}
