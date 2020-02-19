﻿using System.Collections.Immutable;
using CodeGeneration.Roslyn;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Obviously.SemanticTypes.Generator.Modules
{
    public static class SystemTextJsonConverter
    {
        private const string ConverterName = "SystemTextJsonConverter";

        internal static ImmutableArray<ClassDeclarationSyntax> Generate(TypedConstant actualType, TransformationContext context, string identifierName)
        {
            var hasSystemTextJson = context.SemanticModel.Compilation.HasType("System.Text.Json.JsonSerializer");
            if (!hasSystemTextJson)
            {
                return ImmutableArray<ClassDeclarationSyntax>.Empty;
            }

            var @class = ClassDeclaration(ConverterName)
                .WithModifiers(
                    TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.SealedKeyword)))
                .WithBaseList(
                    BaseList(
                        SingletonSeparatedList<BaseTypeSyntax>(
                            SimpleBaseType(
                                QualifiedName(
                                    QualifiedName(
                                        QualifiedName(
                                            QualifiedName(
                                                AliasQualifiedName(
                                                    IdentifierName(
                                                        Token(SyntaxKind.GlobalKeyword)),
                                                    IdentifierName("System")),
                                                IdentifierName("Text")),
                                            IdentifierName("Json")),
                                        IdentifierName("Serialization")),
                                    GenericName(
                                            Identifier("JsonConverter"))
                                        .WithTypeArgumentList(
                                            TypeArgumentList(
                                                SingletonSeparatedList<TypeSyntax>(
                                                    IdentifierName(identifierName)))))))))
                .WithMembers(
                    List(
                        new MemberDeclarationSyntax[]
                        {
                            MethodDeclaration(
                                    IdentifierName(identifierName),
                                    Identifier("Read"))
                                .WithModifiers(
                                    TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.OverrideKeyword)))
                                .WithParameterList(
                                    ParameterList(
                                        SeparatedList<ParameterSyntax>(
                                            new SyntaxNodeOrToken[]
                                            {
                                                Parameter(
                                                        Identifier("reader"))
                                                    .WithModifiers(
                                                        TokenList(
                                                            Token(SyntaxKind.RefKeyword)))
                                                    .WithType(
                                                        QualifiedName(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    AliasQualifiedName(
                                                                        IdentifierName(
                                                                            Token(SyntaxKind.GlobalKeyword)),
                                                                        IdentifierName("System")),
                                                                    IdentifierName("Text")),
                                                                IdentifierName("Json")),
                                                            IdentifierName("Utf8JsonReader"))),
                                                Token(SyntaxKind.CommaToken),
                                                Parameter(
                                                        Identifier("typeToConvert"))
                                                    .WithType(
                                                        QualifiedName(
                                                            AliasQualifiedName(
                                                                IdentifierName(
                                                                    Token(SyntaxKind.GlobalKeyword)),
                                                                IdentifierName("System")),
                                                            IdentifierName("Type"))),
                                                Token(SyntaxKind.CommaToken),
                                                Parameter(
                                                        Identifier("options"))
                                                    .WithType(
                                                        QualifiedName(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    AliasQualifiedName(
                                                                        IdentifierName(
                                                                            Token(SyntaxKind.GlobalKeyword)),
                                                                        IdentifierName("System")),
                                                                    IdentifierName("Text")),
                                                                IdentifierName("Json")),
                                                            IdentifierName("JsonSerializerOptions")))
                                            })))
                                .WithBody(
                                    Block(
                                        LocalDeclarationStatement(
                                            VariableDeclaration(
                                                    IdentifierName("var"))
                                                .WithVariables(
                                                    SingletonSeparatedList(
                                                        VariableDeclarator(
                                                                Identifier("value"))
                                                            .WithInitializer(
                                                                EqualsValueClause(
                                                                    InvocationExpression(
                                                                            MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            AliasQualifiedName(
                                                                                                IdentifierName(
                                                                                                    Token(SyntaxKind.GlobalKeyword)),
                                                                                                IdentifierName("System")),
                                                                                            IdentifierName("Text")),
                                                                                        IdentifierName("Json")),
                                                                                    IdentifierName("JsonSerializer")),
                                                                                GenericName(
                                                                                        Identifier("Deserialize"))
                                                                                    .WithTypeArgumentList(
                                                                                        TypeArgumentList(
                                                                                            SingletonSeparatedList<TypeSyntax>(
                                                                                                IdentifierName(actualType.Value.ToString()))))))
                                                                        .WithArgumentList(
                                                                            ArgumentList(
                                                                                SeparatedList<ArgumentSyntax>(
                                                                                    new SyntaxNodeOrToken[]
                                                                                    {
                                                                                        Argument(
                                                                                                IdentifierName(
                                                                                                    "reader"))
                                                                                            .WithRefKindKeyword(
                                                                                                Token(SyntaxKind
                                                                                                    .RefKeyword)),
                                                                                        Token(SyntaxKind.CommaToken),
                                                                                        Argument(
                                                                                            IdentifierName("options"))
                                                                                    })))))))),
                                        ReturnStatement(
                                            ObjectCreationExpression(
                                                    IdentifierName(identifierName))
                                                .WithArgumentList(
                                                    ArgumentList(
                                                        SingletonSeparatedList(
                                                            Argument(
                                                                IdentifierName("value")))))))),
                            MethodDeclaration(
                                    PredefinedType(
                                        Token(SyntaxKind.VoidKeyword)),
                                    Identifier("Write"))
                                .WithModifiers(
                                    TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.OverrideKeyword)))
                                .WithParameterList(
                                    ParameterList(
                                        SeparatedList<ParameterSyntax>(
                                            new SyntaxNodeOrToken[]
                                            {
                                                Parameter(
                                                        Identifier("writer"))
                                                    .WithType(
                                                        QualifiedName(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    AliasQualifiedName(
                                                                        IdentifierName(
                                                                            Token(SyntaxKind.GlobalKeyword)),
                                                                        IdentifierName("System")),
                                                                    IdentifierName("Text")),
                                                                IdentifierName("Json")),
                                                            IdentifierName("Utf8JsonWriter"))),
                                                Token(SyntaxKind.CommaToken),
                                                Parameter(
                                                        Identifier("value"))
                                                    .WithType(
                                                        IdentifierName(identifierName)),
                                                Token(SyntaxKind.CommaToken),
                                                Parameter(
                                                        Identifier("options"))
                                                    .WithType(
                                                        QualifiedName(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    AliasQualifiedName(
                                                                        IdentifierName(
                                                                            Token(SyntaxKind.GlobalKeyword)),
                                                                        IdentifierName("System")),
                                                                    IdentifierName("Text")),
                                                                IdentifierName("Json")),
                                                            IdentifierName("JsonSerializerOptions")))
                                            })))
                                .WithBody(
                                    Block(
                                        IfStatement(
                                            IsPatternExpression(
                                                IdentifierName("value"),
                                                ConstantPattern(
                                                    LiteralExpression(
                                                        SyntaxKind.NullLiteralExpression))),
                                            ThrowStatement(
                                                ObjectCreationExpression(
                                                        QualifiedName(
                                                            AliasQualifiedName(
                                                                IdentifierName(
                                                                    Token(SyntaxKind.GlobalKeyword)),
                                                                IdentifierName("System")),
                                                            IdentifierName("ArgumentNullException")))
                                                    .WithArgumentList(
                                                        ArgumentList(
                                                            SingletonSeparatedList(
                                                                Argument(
                                                                    InvocationExpression(
                                                                            IdentifierName("nameof"))
                                                                        .WithArgumentList(
                                                                            ArgumentList(
                                                                                SingletonSeparatedList(
                                                                                    Argument(
                                                                                        IdentifierName("value"))))))))))),
                                            ExpressionStatement(
                                                InvocationExpression(
                                                        MemberAccessExpression(
                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                            MemberAccessExpression(
                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                MemberAccessExpression(
                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                    MemberAccessExpression(
                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                        AliasQualifiedName(
                                                                            IdentifierName(
                                                                                Token(SyntaxKind.GlobalKeyword)),
                                                                            IdentifierName("System")),
                                                                        IdentifierName("Text")),
                                                                    IdentifierName("Json")),
                                                                IdentifierName("JsonSerializer")),
                                                            IdentifierName("Serialize")))
                                                    .WithArgumentList(
                                                        ArgumentList(
                                                            SeparatedList<ArgumentSyntax>(
                                                                new SyntaxNodeOrToken[]
                                                                {
                                                                    Argument(
                                                                        IdentifierName("writer")),
                                                                    Token(SyntaxKind.CommaToken),
                                                                    Argument(
                                                                        CastExpression(
                                                                            IdentifierName(actualType.Value.ToString()),
                                                                            IdentifierName("value"))),
                                                                    Token(SyntaxKind.CommaToken),
                                                                    Argument(
                                                                        TypeOfExpression(
                                                                            IdentifierName(actualType.Value.ToString()))),
                                                                    Token(SyntaxKind.CommaToken),
                                                                    Argument(
                                                                        IdentifierName("options"))
                                                                }))))))
                        }));
            return ImmutableArray.CreateRange(new[] { @class });
        }
    }
}