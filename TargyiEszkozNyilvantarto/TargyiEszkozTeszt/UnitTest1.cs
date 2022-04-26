using System;
using System.Linq;
using TargyiEszkozNyilvantarto.Models;
using TargyiEszkozNyilvantarto.Services;
using Xunit;

namespace TargyiEszkozTeszt
{
    public class UnitTest1
    {
        private companyContext context;
        private CoworkerService service;

        public UnitTest1()
        {
            this.context = new companyContext();
            this.service = new CoworkerService(context);
        }
        [Fact]
        public void Test1()
        {
            Assert.Equal(2, service.GetCoworkerNumber());
        }
        [Fact]
        public void Test2()
        {
            Coworker cw = service.GetAllCoworkerByEmail("jos@ka.hu");
            Assert.Equal("Jóska", cw.Name);
            Assert.Equal(1, cw.Notebooks.Count);
        }
        [Fact]
        public void Test3()
        {
            Coworker cw = service.GetAllCoworkerByEmail("pis@ta.hu");
            /*   Assert.Equal("Pistaa", cw.Name);
               Assert.Equal(3, cw.Phones.Count);
               Assert.Equal("Samsung", (Phone)cw.Phones.Where(p => p.Brand == "Samsung").FirstOrDefault());*/
            Assert.True(cw.Phones.Count >= 3);
            Assert.NotNull(cw.Phones.Where(p => p.Brand == "Samsung").FirstOrDefault());
        }
    }
}
