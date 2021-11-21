# Changelog

## [Unreleased] - 2021-11-21
### Changed
- Dropped support of `netcoreapp2.1` in favor of `netcoreapp3.1`.

### Removed
- Dropped support of `netstandard1.3` target platform.

## [0.4.1] - 2020-12-31
### Added
- Rist: `AsSpan()` method.
- Rist: `MoveToArray()` overload providing the actual number of elements.

## [0.4.0] - 2020-12-30
### Added
- Support of `netcoreapp2.1` and `netcoreapp3.1` target platform.
- Nullable annotation and warning contexts.

### Changed
- Updated sources from <https://github.com/dotnet/runtime/tree/v5.0.1>.
- Fictionary: Set `netstandard2.0` as minimum target platform.
- Rist: Set `netstandard1.3` as minimum target platform.

### Removed
- Support of `netcoreapp2.0` target platform.

## Older versions
- [src/Misnomer.Fictionary/CHANGELOG.md](src/Misnomer.Fictionary/CHANGELOG.md)
- [src/Misnomer.Rist/CHANGELOG.md](src/Misnomer.Rist/CHANGELOG.md)

[Unreleased]: https://github.com/qbit86/misnomer/compare/rist-0.4.1...HEAD
[0.4.1]: https://github.com/qbit86/misnomer/compare/misnomer-0.4.0...rist-0.4.1
[0.4.0]: https://github.com/qbit86/misnomer/compare/fictionary-0.2.0...misnomer-0.4.0
