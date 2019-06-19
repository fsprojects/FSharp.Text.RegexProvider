#### 2.1.0
* Add TryTypedMatch that returns an option - https://github.com/fsprojects/FSharp.Text.RegexProvider/issues/20
* Add extension methods on Group to easily and safely convert to primitive types
* Add TypedReplace with typed evaluator
* Make type set local to provider instance to have consitent type names over rebuilds
* Add overload for Match and Matches that takes starting position and number of occurence
* Add ctor overload that takes a timeout

#### 2.0.2 - 17.06.2019
* Fix Nuget page is missing metadata - https://github.com/fsprojects/FSharp.Text.RegexProvider/issues/26
* Https documentation page

#### 2.0.1 - 12.06.2019
* FIx FSharp.Core dependency version in nuget

#### 2.0.0 - 12.06.2019
* Update to net461 and netstandard2.0 - https://github.com/fsprojects/FSharp.Text.RegexProvider/issues/18

#### 1.0.0 - 07.07.2016
* Added a `Typed` prefix to generated methods - https://github.com/fsprojects/FSharp.Text.RegexProvider/issues/16

#### 0.0.7 - 30.05.2015
* Renamed to FSharp.Text.RegexProvider and updated links to project site - https://github.com/fsprojects/FSharp.Text.RegexProvider/issues/11

#### 0.0.6 - 30.05.2015
* Renamed to FSharp.Text.RegexProvider - https://github.com/fsprojects/FSharp.Text.RegexProvider/issues/11

#### 0.0.5 - 22.04.2015
* Add constructor overload that takes regex options - https://github.com/fsprojects/RegexProvider/issues/10

#### 0.0.4 - 27.11.2014
* Fix intellisense hang due to race condition -  https://github.com/fsprojects/RegexProvider/issues/8

#### 0.0.3 - 28.09.2014
* Return provided Match type from Match.NextMatch() - https://github.com/fsprojects/RegexProvider/issues/4

#### 0.0.2 - 23.02.2014
* Changing project to target NET40 (instead of NET45).

#### 0.0.1 - 23.02.2014
* Adding Matches method

#### 0.0.1-alpha - 21.02.2014
* Initial release of RegexProvider
