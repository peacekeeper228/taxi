namespace AuthService.Grpc;

public static class GrpcExt {
    public static IEndpointRouteBuilder AddGrpc(this IEndpointRouteBuilder builder) {
        builder.MapGrpcService<CodeGrpcService>();

        return builder;
    }
}