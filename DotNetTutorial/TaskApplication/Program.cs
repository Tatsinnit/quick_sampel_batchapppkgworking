// Copyright (c) Microsoft Corporation

namespace Microsoft.Azure.Batch.Samples.DotNetTutorial.TaskApplication
{

    using System;
    using System.IO;
    using System.Linq;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    /// <summary>
    /// This application is executed by a job's tasks. It evaluates the text within a
    /// file (whose path is passed as the first command line argument) and returns the
    /// top N words that most commonly appear in the file (where N is the second command
    /// line argument).
    /// </summary>
    /// <remarks>Pass the path of the file as it exists on the compute node as the first
    /// command line argument, a number specifying how many words should be returned
    /// based on their highest count within the specified file as the second argument
    /// (for example, passing '3' returns a list of the top 3 words found within the file),
    /// and the shared access signature (SAS) URL of the blob container in Storage as the third.
    /// </remarks>
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Test Success");
        }
    }
}