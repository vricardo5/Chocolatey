﻿namespace chocolatey.tests.infrastructure.app.utility
{
    using chocolatey.infrastructure.app.utility;
    using NUnit.Framework;
    using Should;

    public class ArgumentsUtilitySpecs
    {
        public abstract class ArgumentsUtilitySpecsBase : TinySpec
        {
            public override void Context()
            {
            }
        }

        [TestFixture("choco install bob --package-parameters-sensitive=\"/test=bill\"", true)]
        [TestFixture("choco install bob -package-parameters-sensitive=\"/test=bill\"", true)]
        [TestFixture("choco install bob --install-arguments-sensitive=\"/test=bill\"", true)]
        [TestFixture("choco install bob -install-arguments-sensitive=\"/test=bill\"", true)]
        [TestFixture("choco apikey -k secretKey -s secretSource", true)]
        [TestFixture("choco config set --name=proxyPassword --value=secretPassword", true)]
        [TestFixture("choco push package.nupkg -k=secretKey", true)]
        [TestFixture("choco source add -n=test -u=bob -p bill", true)]
        [TestFixture("choco source add -n=test -u=bob -p=bill", true)]
        [TestFixture("choco source add -n=test -u=bob -password=bill", true)]
        [TestFixture("choco source add -n=test -cert=text.pfx -cp secretPassword", true)]
        [TestFixture("choco source add -n=test -cert=text.pfx -cp=secretPassword", true)]
        [TestFixture("choco source add -n=test -cert=text.pfx -certpassword=secretPassword", true)]
        [TestFixture("choco push package.nupkg -k secretKey", true)]
        [TestFixture("choco push package.nupkg -k=secretKey", true)]
        [TestFixture("choco push package.nupkg -key secretKey", true)]
        [TestFixture("choco push package.nupkg -key=secretKey", true)]
        [TestFixture("choco install bob -apikey=secretKey", true)]
        [TestFixture("choco install bob -apikey secretKey", true)]
        [TestFixture("choco install bob -api-key=secretKey", true)]
        [TestFixture("choco install bob -api-key secretKey", true)]
        [TestFixture("choco install bob", false)]
        public class when_ArgumentsUtility_is_testing_for_sensitive_parameters : ArgumentsUtilitySpecsBase
        {
            private bool _result;
            private bool _expectedResult;
            private string _commandArguments;

            public when_ArgumentsUtility_is_testing_for_sensitive_parameters(string commandArguments, bool expectedResult)
            {
                _commandArguments = commandArguments;
                _expectedResult = expectedResult;
            }

            public override void Because()
            {
                _result = ArgumentsUtility.arguments_contain_sensitive_information(_commandArguments);
            }

            [Fact]
            public void should_return_expected_result()
            {
                _result.ShouldEqual(_expectedResult);
            }
        }
    }
}
