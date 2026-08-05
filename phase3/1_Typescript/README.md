# TypeScript — What It Actually Adds Over JavaScript

I already know JavaScript (MERN stack), so this project is NOT "OOP,
loops, exceptions" etc — JS already has all of that. This project only
covers the things TypeScript adds ON TOP of JS — the actual reason it
exists as a separate tool at all.

Each folder = one TS-only feature, with a short note on **what breaks
or is unsafe in plain JS, and how TS fixes it.**

## Folder Structure

| # | Folder | What it covers | Why plain JS can't do this |
|---|--------|----------------|------------------------------|
| 1 | `1_TypeAnnotationsInference` | Declaring types, and TS auto-inferring types | JS variables can silently hold any type, and change type mid-way |
| 2 | `2_InterfacesTypeAliases` | `interface` / `type` — describing the shape of data | JS has no way to describe/enforce an object's shape |
| 3 | `3_UnionIntersectionTypes` | `A \| B` and `A & B` | JS can't restrict a value to "only these specific types" |
| 4 | `4_TypeNarrowingGuards` | Safely handling union types at runtime | Related to #3 — this is how you actually use a union safely |
| 5 | `5_Enums` | `enum Status { Active, Inactive }` | JS has no enum keyword — people fake it with plain objects |
| 6 | `6_Generics` | Reusable, type-safe functions/classes `<T>` | JS has no compile-time type checking at all, so nothing to make generic |
| 7 | `7_AccessModifiers` | Real `private` / `protected` / `readonly` enforced at compile time | JS's `#private` is newer, weaker, and has no `protected`/`readonly` |
| 8 | `8_UtilityTypes` | `Partial<T>`, `Pick<T>`, `Omit<T>`, `Readonly<T>` | JS has no type system, so no way to transform a "shape" into another shape |
| 9 | `9_UnknownVsAny` | `unknown` vs `any` | JS's default behavior for uncertain data is basically all `any` — zero safety |
| 10 | `10_StrictNullChecks` | Forcing explicit handling of `null` / `undefined` | JS lets `null`/`undefined` sneak in anywhere and crash at runtime |
| 11 | `11_FunctionOverloads` | Multiple call signatures for one function | JS functions accept anything, so there's nothing to "overload" |
| 12 | `12_TypeAssertionsSatisfies` | `as Type` and the `satisfies` operator | JS has no compiler, so there's no type to assert or check against |

## How to run any file

```bash
npm install
npx ts-node "<folder>/index.ts"
```

## How I'd explain this to my mentor in one line

> "Everything in this folder is something TypeScript adds that
> JavaScript literally cannot do — not stuff JS already had, like
> classes or async/await."
