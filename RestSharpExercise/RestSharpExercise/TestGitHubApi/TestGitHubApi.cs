using RestSharpServices;
using System.Net;
using System.Reflection.Emit;
using System.Text.Json;
using RestSharp;
using RestSharp.Authenticators;
using NUnit.Framework.Internal;
using RestSharpServices.Models;
using System;

namespace TestGitHubApi
{
    public class TestGitHubApi
    {
        private GitHubApiClient client;
        private static string repo;
        private static int lastCreatedIssueNumber;
        private static int lastCreatedIssueCommentId;

        [SetUp]
        public void Setup()
        {
            client = new GitHubApiClient("https://api.github.com/repos/testnakov/", "null", "null");
            repo = "test-nakov-repo";
        }


        [Test, Order(1)]
        public void Test_GetAllIssuesFromARepo()
        {
            var issues = client.GetAllIssues(repo);
            Assert.That(issues, Has.Count.GreaterThan(0),
                "There should be more than one issue.");
            foreach (Issue issue in issues)
            {
                Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
                Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be greater than 0.");
                Assert.That(issue.Title, Is.Not.Empty, "Issue title should not be empty.");
            }
        
        }

        [Test, Order (2)]
        public void Test_GetIssueByValidNumber()
        {
            int issueNumber = 1;
            var issue = client.GetIssueByNumber(repo, issueNumber);
            Assert.That(issue, Is.Not.Null, "The response, should contain issue data.");
            Assert.That(issue.Id, Is.GreaterThan(0), "Issue ID should be greater than 0.");
            Assert.That(issue.Number, Is.GreaterThan(0), "Issue Number should be requested.");
            Assert.That(issue.Title, Is.Not.Empty, "Issue title should not be empty.");
        }
        
        [Test, Order (3)]
        public void Test_GetAllLabelsForIssue()
        {
            int issueNumber = 6;
            var labels = client.GetAllLabelsForIssue(repo, issueNumber);

            Assert.That(labels.Count, Is.GreaterThan(0), "There should be labels on the issue");
            foreach (var label in labels)
            {
                Assert.That(label.Id, Is.GreaterThan(0), "Label ID should be more than 0");
                Assert.That(label.Name, Is.Not.Null, "Label Name should not be null");

                Console.WriteLine($"Label: {label.Id} - Name: {label.Name}");


            }

        }

        [Test, Order(4)]
        public void Test_GetAllCommentsForIssue()
        {
            int issueNumber = 1;
            var comments = client.GetAllCommentsForIssue(repo, issueNumber);

            Assert.That(comments.Count, Is.GreaterThan(0), "There should be comments on the issue");
            foreach (var comment in comments)
            {
                Assert.That(comment.Id, Is.GreaterThan(0), "Comment ID should be more than 0.");
                Assert.That(comment.Body, Is.Not.Empty, "Comment Body should not be empty.");

                Console.WriteLine($"Comment: {comment.Id} - Body: {comment.Body}");

            }
        }
            [Test, Order(5)]
        public void Test_CreateGitHubIssue()
        {
            
            string title = "New Issue";
            string body = "This is the body of the new issue";

            var issue = client.CreateIssue(repo, title, body);
            Assert.Multiple(() =>
            {

    
            Assert.That(issue.Id, Is.GreaterThan(0), "The new issue should have ID");
            Assert.That(issue.Number, Is.GreaterThan(0));
            Assert.That(issue.Title, Is.Not.Empty);
            Assert.That(issue.Title, Is.EqualTo(title));
            });
            Console.WriteLine(issue.Number);
            lastCreatedIssueNumber = issue.Number;

        }

        [Test, Order (6)]
        public void Test_CreateCommentOnGitHubIssue()
        {
            int issueNumber = 1;
            string body = "This is the body of the new issue";

            var comment = client.CreateCommentOnGitHubIssue(repo, issueNumber, body);

            Assert.That(comment.Body, Is.EqualTo(body));

            Console.WriteLine(comment.Id);
            lastCreatedIssueCommentId = comment.Id;

        }

        [Test, Order (7)]
        public void Test_GetCommentById()
        {
            int commentId = 1;

            var comment = client.GetCommentById(repo, commentId);

            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(commentId));
        }


        [Test, Order (8)]
        public void Test_EditCommentOnGitHubIssue()
        {
            int commentId = 1;
            string newBody = "Edited comment on this issue";

            var comment = client.EditCommentOnGitHubIssue(repo, commentId, newBody);

            Assert.That(comment, Is.Not.Null);
            Assert.That(comment.Id, Is.EqualTo(commentId));
            Assert.That(comment.Body, Is.EqualTo(newBody));
            
        }

        [Test, Order (9)]
        public void Test_DeleteCommentOnGitHubIssue()
        {
            int commentId = 1;
          

            var result = client.DeleteCommentOnGitHubIssue(repo, commentId);

            Assert.That(result, Is.True);


        }


    }
}

