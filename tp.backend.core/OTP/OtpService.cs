using Microsoft.Extensions.Options;
using Serilog;
using tp.backend.core.Cache;
using tp.backend.core.Exceptions;

namespace tp.backend.core.OTP;

internal class OtpService : IOtpService
{
    private const string Chars = "0123456789";
    private readonly Random _generator;
    private readonly ILogger _logger;
    private readonly OtpOptions _options;
    private readonly ICacheStore _store;

    public OtpService(IOptions<OtpOptions> options, ICacheStore store, ILogger logger)
    {
        _store = store;
        _logger = logger.ForContext<OtpService>();
        _options = options.Value;
        _generator = new Random();
    }

    public async Task<OtpResult> Generate(string key, OtpType type)
    {
        var token = GetOtpToken(_options.Digits);
        await _store.StoreAsync(GenerateKey(key, type), new CacheObject
        {
            Token = token
        }, _options.Duration);

        return new OtpResult
        {
            Duration = _options.Duration,
            Type = type,
            OtpToken = token
        };
    }

    public async Task<bool> Validate(string key, OtpType type, string otpToken)
    {
        try
        {
            var item = await _store.Get<CacheObject>(GenerateKey(key, type));
            return item.Token.Equals(otpToken);
        }
        catch (NotFoundException nf)
        {
            return false;
        }
        catch (Exception e)
        {
            _logger.Error(e.Message);
            throw;
        }
    }

    private string GenerateKey(string key, OtpType type)
    {
        return $"{_options.TokenPrefix}:{type}:{key}";
    }

    private string GetOtpToken(int length)
    {
        return new string(Enumerable.Repeat(Chars, length)
            .Select(s => s[_generator.Next(s.Length)]).ToArray());
    }

    private class CacheObject
    {
        public string Token { get; set; }
    }
}