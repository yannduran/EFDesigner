# Contributing

Contributions are always welcome! [Clone a copy of the project](https://github.com/msawczyn/EFDesigner) and have at it!

I'll attempt to work any pull requests within a few days, but can't promise anything in
stone since life can, at times, get in the way &lt;g&gt;. 

The only special setup you'll need is the [Visualization & Modeling SDK](https://blogs.msdn.microsoft.com/devops/2016/12/12/the-visual-studio-modeling-sdk-is-now-available-with-visual-studio-2017/), 
formerly known as DSL Tools, which [can now be found in the Visual Studio installer](https://blogs.msdn.microsoft.com/devops/2016/12/12/the-visual-studio-modeling-sdk-is-now-available-with-visual-studio-2017/). 
Just make sure that's been activated.

## Special Note

There's currently a bug in the templates used in DSL generation in the SDK. You'll need to fix it to make
things work.

First, find the DSL Tools text templates. In my installation, they're located at

```
C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\Extensions\Microsoft\DSL SDK\DSL Designer\15.0\TextTemplates
```

But the `Enterprise` part of that path is there because I'm running Visual Studio Enterprise ... YMMV.

In the `Dsl` folder you'll find `SerializationHelper.tt`. Open it in your favorite text editor.

On line 617 you'll see

```
this.OnPostLoadModel(serializationResult, partition, fileName, modelRoot);
```

change that to

```
this.OnPostLoadModel(serializationResult, partition, location, modelRoot);
```

The bug got introduced when the load process got expanded to load from a stream rather than from
just a file. The parameter name of the surrounding function got changed, but this call didn't and,
from the looks of it, test code coverage never caused this to get used in generation. 

You'll have to make this change every time the SDK gets updated. It was [reported in March of 2017](https://developercommunity.visualstudio.com/content/problem/37185/vs2017-dsl-tools-error-in-serializationhelpertt.html)
and [again in October of the same year](https://developercommunity.visualstudio.com/content/problem/128359/dslmodeling-error-in-generatedcode-of-serializatio.html) 
but is still a problem.

If you have *other* any problems compiling the code, please add an issue to the 
[GitHub issues list](https://github.com/msawczyn/EFDesigner/issues).

And if you'd like to contribute but aren't a programmer, there's still room for you!
The project docs (the thing you're reading) could certainly be improved - it would be
great if qualified writers could help.

Looking forward to your efforts! And thanks in advance.


