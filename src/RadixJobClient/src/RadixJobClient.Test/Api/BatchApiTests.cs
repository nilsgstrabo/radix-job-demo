/*
 * Radix job scheduler server.
 *
 * This is the API Server for the Radix job scheduler server.
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using RadixJobClient.Client;
using RadixJobClient.Api;
// uncomment below to import models
//using RadixJobClient.Model;

namespace RadixJobClient.Test.Api
{
    /// <summary>
    ///  Class for testing BatchApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class BatchApiTests : IDisposable
    {
        private BatchApi instance;

        public BatchApiTests()
        {
            instance = new BatchApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of BatchApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' BatchApi
            //Assert.IsType<BatchApi>(instance);
        }

        /// <summary>
        /// Test CreateBatch
        /// </summary>
        [Fact]
        public void CreateBatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //BatchScheduleDescription batchCreation = null;
            //var response = instance.CreateBatch(batchCreation);
            //Assert.IsType<BatchStatus>(response);
        }

        /// <summary>
        /// Test DeleteBatch
        /// </summary>
        [Fact]
        public void DeleteBatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string batchName = null;
            //var response = instance.DeleteBatch(batchName);
            //Assert.IsType<Status>(response);
        }

        /// <summary>
        /// Test GetBatch
        /// </summary>
        [Fact]
        public void GetBatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string batchName = null;
            //var response = instance.GetBatch(batchName);
            //Assert.IsType<BatchStatus>(response);
        }

        /// <summary>
        /// Test GetBatchJob
        /// </summary>
        [Fact]
        public void GetBatchJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string batchName = null;
            //string jobName = null;
            //var response = instance.GetBatchJob(batchName, jobName);
            //Assert.IsType<JobStatus>(response);
        }

        /// <summary>
        /// Test GetBatches
        /// </summary>
        [Fact]
        public void GetBatchesTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetBatches();
            //Assert.IsType<List<BatchStatus>>(response);
        }

        /// <summary>
        /// Test StopBatch
        /// </summary>
        [Fact]
        public void StopBatchTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string batchName = null;
            //var response = instance.StopBatch(batchName);
            //Assert.IsType<Status>(response);
        }

        /// <summary>
        /// Test StopBatchJob
        /// </summary>
        [Fact]
        public void StopBatchJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string batchName = null;
            //string jobName = null;
            //var response = instance.StopBatchJob(batchName, jobName);
            //Assert.IsType<Status>(response);
        }
    }
}
