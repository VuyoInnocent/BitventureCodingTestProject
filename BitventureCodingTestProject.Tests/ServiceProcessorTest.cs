using System;
using System.IO;
using BitventureCodingTestProject.Models.Requests;
using BitventureCodingTestProject.Processsors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BitventureCodingTestProject.Tests
{
    [TestClass]
    public class ServiceProcessorTest
    {
        readonly ServiceProcessor service;

        public ServiceProcessorTest()
        {
            service = new ServiceProcessor();
        }
        [TestMethod]
        public void MapJsonFile_MapJsonDataToObject_MappedData()
        {
            
            // Arrange
            string InputFile = @"C:\TopSecret\Projects\Bitventure\Requirements\bonus_endpoints.json";

            JsonMapper expectedResults = null;

            using (StreamReader read = new StreamReader(InputFile))
            {
                string jsonData = read.ReadToEnd();

                expectedResults = JsonConvert.DeserializeObject<JsonMapper>(jsonData);
            }

            var expect = false;
            if (expectedResults != null)
            {
                expect = true;
            }

            //Act
            var actualResults = service.MapJsonFile(InputFile);

            var actual = false;
            if (actualResults != null)
            {
                actual = true;
            }
            //Asset
            Assert.AreEqual(expect, actual);
        }
    }
}
