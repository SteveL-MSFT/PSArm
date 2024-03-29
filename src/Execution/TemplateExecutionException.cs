
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Management.Automation;

namespace PSArm.Execution
{
    public class TemplateExecutionException : Exception
    {
        public TemplateExecutionException(string message, ErrorRecord errorRecord)
            : base(message)
        {
            ErrorRecord = errorRecord;
        }

        public TemplateExecutionException(ErrorRecord errorRecord)
        {
            ErrorRecord = errorRecord;
        }

        public ErrorRecord ErrorRecord { get; }
    }
}
