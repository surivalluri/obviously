# Changelog

All notable changes to this project will be documented in this file.  
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/).

## [Unreleased]

## 0.0.1-preview.7 - 2020-04-15 <a name="0.0.1-preview.7"> </a>

### Changed

* Simplified installation, only install the package `Obviously.SemanticTypes`
* Nullability enabled

### Added

* Support for Json.NET. A converter named `JsonNetConverter` is generated as a nested class.
* Support for System.Text.Json. A converter `SystemTextJsonConverter` is generated as a nested class.

## 0.0.1-preview.4 - 2020-01-12 <a name="0.0.1-preview.4"> </a>

### Added

* *Module ASP.NET Core:* Creates the __ASP.NET Core MVC Model Binder__ and __Model Binder Provider__ for the semantic type, only if the project has a reference to the assembly `Microsoft.AspNetCore.Mvc`
  * The __Model Binder Provider__ has to be registered in the ``StartUp``.
