using System;
using System.Collections.Generic;
using System.Text;
using FamilyFriendlyCampsite;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DatabaseTestProject 
{
    [TestClass]
    public class CampsiteRepoTest
    {
        private CampsiteRepository campsiteRepository;

        [TestInitialize]
        public void Setup()
        {
           campsiteRepository = new CampsiteRepository();
        }


        [TestMethod]
        public void GetCampsitesShouldReturnCampsites()
        {
            var stuff = campsiteRepository.GetCampsites();
            Assert.IsNotNull(stuff);
        }
    }
}
