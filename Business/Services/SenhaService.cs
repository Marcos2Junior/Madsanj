using Business.Services.ImplementInterface;
using Data;
using Data.ModelDb;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services
{
    public class SenhaService : CRUD
    {
        private ExceptionFull _exception = new ExceptionFull();

        public SenhaService(MadsanjContext context) : base(context) { }
    }
}
