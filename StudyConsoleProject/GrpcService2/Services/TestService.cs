using Grpc.Core;
using GrpcService2.ProtoBuf;
using GrpcService2.ProtoBuf.Messages;

namespace GrpcService2.Services
{
    public class TestService : TestGrpcService.TestGrpcServiceBase
    {
        public override Task<TestGrpcMessage> Test(TestGrpcMessage request, ServerCallContext context)
        {
            request.Data = $"Response on: {request.Data}";
            return Task.FromResult(request);
        }
    }
}
