using NUnit.Framework;
using UITestsProject.Constants.TestProjectConstants;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(EnvironmentConstants.NumberOfParallerThreads)]
