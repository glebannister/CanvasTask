using NUnit.Framework;
using UITestsProject.Configuration.Constants.TestProjectConstants;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(EnvironmentConstants.NumberOfParallerThreads)]
