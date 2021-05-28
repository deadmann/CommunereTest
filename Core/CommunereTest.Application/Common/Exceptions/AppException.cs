using System;
using System.Collections.Generic;
using System.Linq;
using CommunereTest.Domain.Models;

namespace CommunereTest.Application.Common.Exceptions
{
    public class AppException : Exception
    {
        public IDictionary<string, string[]> Failures { get; }

        public AppException() : base("One or more application failures have occurred.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public AppException(string property, string message) : this()
        {
            var failures = new List<AppFailure>
            {
                new AppFailure(property, message)
            };

            SetFailures(failures);
        }

        public AppException(List<AppFailure> failures) : this()
        {
            SetFailures(failures);
        }

        private void SetFailures(List<AppFailure> failures)
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }
    }
}
