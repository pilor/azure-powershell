﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System.IO;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Microsoft.WindowsAzure.Commands.CloudService.Development.Scaffolding;
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.CloudService;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.WindowsAzure.Commands.Utilities.Properties;
using Microsoft.WindowsAzure.Commands.Common;
using System;
using Microsoft.Azure.Commands.Common.Authentication;

namespace Microsoft.WindowsAzure.Commands.Test.CloudService.Development.Scaffolding
{
    
    public class AddAzureWorkerRoleTests : SMTestBase
    {
        private MockCommandRuntime mockCommandRuntime;

        private AddAzureWorkerRoleCommand addWorkerCmdlet;

        public AddAzureWorkerRoleTests()
        {
            AzurePowerShell.ProfileDirectory = Test.Utilities.Common.Data.AzureSdkAppDir;
            mockCommandRuntime = new MockCommandRuntime();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureWorkerRoleProcess()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WorkerRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string expectedVerboseMessage = string.Format(Resources.AddRoleMessageCreate, rootPath, roleName);
                TestMockSupport.TestExecutionFolder = rootPath;
                addWorkerCmdlet = new AddAzureWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = roleName };

                addWorkerCmdlet.ExecuteCmdlet();

                AzureAssert.ScaffoldingExists(Path.Combine(rootPath, roleName), Path.Combine(Resources.GeneralScaffolding, Resources.WorkerRole));
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.RoleName));
                Assert.Equal<string>(expectedVerboseMessage, mockCommandRuntime.VerboseStream[0]);
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureWorkerRoleWillRecreateDeploymentSettings()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WorkerRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string expectedVerboseMessage = string.Format(Resources.AddRoleMessageCreate, rootPath, roleName);
                string settingsFilePath = Path.Combine(rootPath, Resources.SettingsFileName);
                TestMockSupport.TestExecutionFolder = rootPath;
                File.Delete(settingsFilePath);
                Assert.False(File.Exists(settingsFilePath));
                addWorkerCmdlet = new AddAzureWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = roleName };

                addWorkerCmdlet.ExecuteCmdlet();

                AzureAssert.ScaffoldingExists(Path.Combine(rootPath, roleName), Path.Combine(Resources.GeneralScaffolding, Resources.WorkerRole));
                Assert.Equal<string>(roleName, ((PSObject)mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.RoleName));
                Assert.Equal<string>(expectedVerboseMessage, mockCommandRuntime.VerboseStream[0]);
                Assert.True(File.Exists(settingsFilePath));
            }
        }

        [Fact(Skip = "TODO: Fix SetScaffolding in CloudServiceProject.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureWorkerRoleWithTemplateFolder()
        {
            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WorkerRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                string expectedVerboseMessage = string.Format(Resources.AddRoleMessageCreate, rootPath, roleName);
                string scaffoldingPath = "MyWorkerTemplateFolder";
                using (new DirStack(rootPath))
                {
                    addWorkerCmdlet = new AddAzureWorkerRoleCommand()
                    {
                        RootPath = rootPath,
                        CommandRuntime = mockCommandRuntime,
                        Name = roleName,
                        TemplateFolder = scaffoldingPath
                    };

                    addWorkerCmdlet.ExecuteCmdlet();

                    AzureAssert.ScaffoldingExists(Path.Combine(rootPath, roleName), scaffoldingPath);
                    Assert.Equal<string>(roleName,
                        ((PSObject) mockCommandRuntime.OutputPipeline[0]).GetVariableValue<string>(Parameters.RoleName));
                    Assert.Equal<string>(expectedVerboseMessage, mockCommandRuntime.VerboseStream[0]);
                }
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AddAzureWorkerRoleWithMissingScaffoldXmlFail()
        {
            string scaffoldingPath = "TemplateMissingScaffoldXml";
            Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, scaffoldingPath));

            using (FileSystemHelper files = new FileSystemHelper(this))
            {
                string roleName = "WorkerRole1";
                string serviceName = "AzureService";
                string rootPath = files.CreateNewService(serviceName);
                addWorkerCmdlet = new AddAzureWorkerRoleCommand() { RootPath = rootPath, CommandRuntime = mockCommandRuntime, Name = roleName, TemplateFolder = scaffoldingPath };

                Testing.AssertThrows<FileNotFoundException>(() => addWorkerCmdlet.ExecuteCmdlet());
            }
        }
    }
}
