using HelloWorldHelper.BussinessLogic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace HelloWorldTest.BussinessLogic; 

public class MessagesTests
{
    [Fact]
	public void Greetinf_InEnglish()
	{
		ILogger<Messages> logger = new NullLogger<Messages>();
		Messages messages = new(logger);

		string expected = "Hello World";
		string actual = messages.Greeting("en"); 

		Assert.Equal(expected, actual);
	}

    [Fact]
    public void Greetinf_InSpanish()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        string expected = "Hola Mundo";
        string actual = messages.Greeting("es");

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Greetinf_Invalid()
    {
        ILogger<Messages> logger = new NullLogger<Messages>();
        Messages messages = new(logger);

        Assert.Throws<InvalidOperationException>(
            () => messages.Greeting("fr")
            );

    }
}
