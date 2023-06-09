﻿// Copyright © 2017 - 2021 Chocolatey Software, Inc
// Copyright © 2011 - 2017 RealDimensions Software, LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
//
// You may obtain a copy of the License at
//
// 	http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace chocolatey.infrastructure.commands
{
    using System;
    using System.Diagnostics;

    public interface ICommandExecutor
    {
        int execute(string process, string arguments, int waitForExitInSeconds);
        int execute(string process, string arguments, int waitForExitInSeconds, string workingDirectory);

        int execute(
            string process,
            string arguments,
            int waitForExitInSeconds,
            Action<object, DataReceivedEventArgs> stdOutAction,
            Action<object, DataReceivedEventArgs> stdErrAction,
            bool updateProcessPath
            );

        int execute(
            string process,
            string arguments,
            int waitForExitInSeconds,
            string workingDirectory,
            Action<object, DataReceivedEventArgs> stdOutAction,
            Action<object, DataReceivedEventArgs> stdErrAction,
            bool updateProcessPath,
            bool allowUseWindow
            );

        int execute(
            string process,
            string arguments,
            int waitForExitInSeconds,
            string workingDirectory,
            Action<object, DataReceivedEventArgs> stdOutAction,
            Action<object, DataReceivedEventArgs> stdErrAction,
            bool updateProcessPath,
            bool allowUseWindow,
            bool waitForExit
            );
    }
}
