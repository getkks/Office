namespace Office

open System.Collections.Generic

/// <summary>
/// Automation scaffolding.
/// </summary>
module rec Automation =

    /// <summary>
    /// Automation properties and required paths.
    /// </summary>
    type Automation = {
        /// <summary>
        /// The name of the automation.
        /// </summary>
        Name: string
        /// <summary>
        /// The description for the automation.
        /// </summary>
        Description: string
        /// <summary>
        /// The paths for the automation. Order of path within each path type is important.
        /// </summary>
        Paths: IReadOnlyDictionary<PathType, string Stack>
    }

    /// <summary>
    /// Path types for the automation.
    /// </summary>
    type PathType =
        /// <summary>
        /// The base path.
        /// </summary>
        | Base = 0
        /// <summary>
        /// The code path. Optional.
        /// </summary>
        | Code = 1
        /// <summary>
        /// The data path.
        /// </summary>
        | Data = 2
        /// <summary>
        /// The support path.
        /// </summary>
        | Support = 3
        /// <summary>
        /// The template path.
        /// </summary>
        | Template = 4

    let create name description =
        let paths = Dictionary()
        paths.Add(PathType.Base, Stack())
        paths.Add(PathType.Code, Stack())
        paths.Add(PathType.Data, Stack())
        paths.Add(PathType.Support, Stack())
        paths.Add(PathType.Template, Stack())

        {
            Name = name
            Description = description
            Paths = paths
        }

    let addPath pathType path automation = automation.Paths[pathType].Push path
