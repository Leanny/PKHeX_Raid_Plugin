using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKHeX_Raid_Plugin;

/// <summary>
/// Encodes commands to be sent as a <see cref="byte"/> array to a Nintendo Switch running a sys-module.
/// </summary>
public static class SwitchCommand
{
    public const decimal BotbaseVersion = 2.4m;
    public const string VersionNumber = "1.3.2";
    public const string SwordID = "0100ABF008968000";
    public const string ShieldID = "01008DB008C2C000";

    private static readonly Encoding Encoder = Encoding.ASCII;

    private static byte[] Encode(string command, bool crlf = true) 
        => Encoder.GetBytes(crlf ? command + "\r\n" : command);

    private static string ToHex(ReadOnlySpan<byte> data) => Convert.ToHexString(data);

    public static byte[] ConvertHexByteStringToBytes(ReadOnlySpan<byte> bytes) => Convert.FromHexString(bytes);

    public static void LoadHexBytesTo(ReadOnlySpan<byte> str, Span<byte> dest)
    {
        // The input string is 2-char hex values optionally separated.
        // The destination array should always be larger or equal than the bytes written. Let the runtime bounds check us.
        Convert.FromHexString(str, dest, out _, out _);
    }

    /*
     *
     * Memory I/O Commands
     *
     */

    /// <summary>
    /// Requests the Bot to send <see cref="count"/> bytes from <see cref="offset"/>.
    /// </summary>
    /// <param name="offset">Address of the data</param>
    /// <param name="count">Amount of bytes</param>
    /// <param name="crlf">Line terminator (unused by USB protocol)</param>
    /// <returns>Encoded command bytes</returns>
    public static byte[] Peek(uint offset, int count, bool crlf = true)
        => Encode($"peek 0x{offset:X8} {count}", crlf);

    /// <summary>
    /// Sends the Bot <see cref="data"/> to be written to <see cref="offset"/>.
    /// </summary>
    /// <param name="offset">Address of the data</param>
    /// <param name="data">Data to write</param>
    /// <param name="crlf">Line terminator (unused by USB protocol)</param>
    /// <returns>Encoded command bytes</returns>
    public static byte[] Poke(uint offset, ReadOnlySpan<byte> data, bool crlf = true)
        => Encode($"poke 0x{offset:X8} 0x{ToHex(data)}", crlf);
    /*
     *
     * Process Info Commands
     *
     */

    /// <summary>
    /// Requests the title id of attached process.
    /// </summary>
    /// <param name="crlf">Line terminator (unused by USB protocol)</param>
    /// <returns>Encoded command bytes</returns>
    public static byte[] GetTitleID(bool crlf = true)
        => Encode("getTitleID", crlf);

    /// <summary>
    /// Requests the sys-botbase or usb-botbase version.
    /// </summary>
    /// <param name="crlf">Line terminator (unused by USB protocol)</param>
    /// <returns>Encoded command bytes</returns>
    public static byte[] GetBotbaseVersion(bool crlf = true)
        => Encode("getVersion", crlf);

    /// <summary>
    /// Receives requested information about the currently running game application.
    /// </summary>
    /// <param name="info">Valid parameters and their return types: icon (byte[]), version (string), rating (int), author (string), name (string)</param>
    /// <param name="crlf">Line terminator (unused by USB's protocol)</param>
    /// <returns>Encoded command bytes</returns>
    public static byte[] GetGameInfo(ReadOnlySpan<char> info, bool crlf = true)
        => Encode($"game {info}", crlf);

}
