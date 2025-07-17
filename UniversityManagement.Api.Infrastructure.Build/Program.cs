using ADotNet.Clients;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks;
using ADotNet.Models.Pipelines.GithubPipelines.DotNets.Tasks.SetupDotNetTaskV1s;

namespace UniversityManagement.Api.Infrastructure.Build
{
    public class Program
    {
        static void Main(string[] args)
        {
            var githubPipeline = new GithubPipeline
            {
                Name = "University Management Build Pipeline",

                OnEvents = new Events
                {
                    PullRequest = new PullRequestEvent
                    {
                        Branches = new string[] { "main" }
                    },

                    Push = new PushEvent
                    {
                        Branches = new string[] { "main" }
                    }
                },

                Jobs = new Dictionary<string, Job>
                {
                    {
                        "build",
                        new Job
                        {
                            RunsOn = BuildMachines.Windows2022,

                            Steps = new List<GithubTask>
                            {
                                new CheckoutTaskV2
                                {
                                    Name = "Checking Out Code"
                                },

                                new SetupDotNetTaskV1
                                {
                                    Name = "Setting up .NET",
                                    TargetDotNetVersion = new TargetDotNetVersion
                                    {
                                        DotNetVersion = "8.0.412"
                                    }
                                },

                                new RestoreTask
                                {
                                    Name = "Restoring Nuget Packages"
                                },

                                new DotNetBuildTask
                                {
                                    Name = "Building Project"
                                },

                                new TestTask
                                {
                                    Name = "Running Tests"
                                }
                            }
                        }
                    }
                }
            };

            var client = new ADotNetClient();

            client.SerializeAndWriteToFile(
                adoPipeline: githubPipeline,
                path: "../../../../.github/workflows/dotnet.yml");
        }
    }
}
