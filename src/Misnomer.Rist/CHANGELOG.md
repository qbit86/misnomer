# Changelog

## Newer versions
- [../../CHANGELOG.md](../../CHANGELOG.md)

## [0.3.0] - 2019-01-22
### Changed
- Made `Rist<T>` sealed. This is breaking change but can [improve performance](https://reubenbond.github.io/posts/dotnet-perf-tuning).

### Removed 
- Merged removing `_syncRoot` in order to [reduce size](https://github.com/dotnet/corefx/issues/34149) of collection.

## [0.2.2] - 2018-12-19
### Added
- `netcoreapp1.0` as separate target framework to remove dependency from `System.Buffers`.

### Changed
- Replaced license URL with [license expression](https://spdx.org/licenses/).

## [0.2.1] - 2018-12-01
### Changed
- Merged [fix](https://github.com/dotnet/corefx/commit/0341782cb944cc89dadfcec144399bbda26656e6) for `List<T>`.

## [0.2.0] - 2018-10-27
### Added
- `RistBenchmark` class for measuring allocations.
- `netstandard2.0` and `net461` targets.
- Strong naming with open-source key.
- Embedded [portable PDBs](https://github.com/dotnet/core/blob/master/Documentation/diagnostics/portable_pdb.md) in the main package.
- Integrated [Source Link](https://docs.microsoft.com/en-us/dotnet/standard/library-guidance/sourcelink) to enable source code debugging.

## [0.1.1] - 2018-09-17
### Added
- This [CHANGELOG.md](https://keepachangelog.com) file.
- CONTRIBUTING.md file.

### Changed
- Update [System.Buffers](https://www.nuget.org/packages/System.Buffers) from 4.4.0 to 4.5.0.

## 0.1.0 - 2018-09-15
### Added
- `Rist<T>` generic class for recyclable list.

[0.3.0]: https://github.com/qbit86/misnomer/compare/rist-0.2.2...rist-0.3.0
[0.2.2]: https://github.com/qbit86/misnomer/compare/rist-0.2.1...rist-0.2.2
[0.2.1]: https://github.com/qbit86/misnomer/compare/rist-0.2.0...rist-0.2.1
[0.2.0]: https://github.com/qbit86/misnomer/compare/rist-0.1.1...rist-0.2.0
[0.1.1]: https://github.com/qbit86/misnomer/compare/rist-0.1.0...rist-0.1.1
