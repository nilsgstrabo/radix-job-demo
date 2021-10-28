/*
 * classification Radix API.
 *
 * This is the API Server for the Radix job scheduler.
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
    ///  Class for testing JobApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class JobApiTests : IDisposable
    {
        private JobApi instance;

        public JobApiTests()
        {
            instance = new JobApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of JobApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' JobApi
            //Assert.IsType<JobApi>(instance);
        }

        /// <summary>
        /// Test CreateJob
        /// </summary>
        [Fact]
        public void CreateJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //JobScheduleDescription jobCreation = null;
            //var response = instance.CreateJob(jobCreation);
            //Assert.IsType<JobStatus>(response);
        }

        /// <summary>
        /// Test DeleteJob
        /// </summary>
        [Fact]
        public void DeleteJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobName = null;
            //var response = instance.DeleteJob(jobName);
            //Assert.IsType<Status>(response);
        }

        /// <summary>
        /// Test GetJob
        /// </summary>
        [Fact]
        public void GetJobTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //string jobName = null;
            //var response = instance.GetJob(jobName);
            //Assert.IsType<JobStatus>(response);
        }

        /// <summary>
        /// Test GetJobs
        /// </summary>
        [Fact]
        public void GetJobsTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //var response = instance.GetJobs();
            //Assert.IsType<List<JobStatus>>(response);
        }
    }
}
