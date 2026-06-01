# CopCar

CopCar is a Unity/C# arcade chase project focused on lane-based driving, traffic spawning, collision flow, collectible timing, and restartable game state.

This public repository keeps the gameplay code, Unity project metadata, documentation, and edit-mode tests. Art packages and playable scene assets are intentionally excluded from the public version, so the repository is best reviewed as a code-focused Unity sample.

## Highlights

- Four-lane highway layout with centralized lane coordinates
- Traffic spawning that avoids repeating the previous lane
- Reactive suspect vehicle lane changes when a lane becomes blocked
- Star timing rules for staged collectible spawns
- Collision relays for scoring, chase-state cleanup, and run-ending impacts
- Partial-class organization for gameplay loop, setup, spawning, level flow, and input
- Edit-mode tests for deterministic gameplay services
- Repository hygiene checks in GitHub Actions

## Tech Stack

- Unity 2019.2.2f1
- C#
- Unity physics collisions
- Unity Test Framework with NUnit
- GitHub Actions for metadata and repository checks

## Project Structure

```text
Assets/
  Scripts/
    MainScript.cs
    MainScriptParts/
    ChaseCollision.cs
    ChaseCollisionParts/
    Services/
    AddStars.cs
    ChaseCollision2.cs
    EndColl.cs
    GameOver.cs
    StarColl.cs
  Tests/
    EditMode/
docs/
scripts/
```

## Core Systems

`MainScript` owns the run lifecycle: setup, forward movement, traffic creation, road recycling, score state, restart state, and input.

`ChaseCollision` owns the suspect vehicle state. It tracks occupied lanes, selects a safe adjacent target lane, and moves the vehicle smoothly toward that lane.

`Services` contains small deterministic classes that are easy to test:

- `LaneLayout` keeps lane IDs and X positions in one place.
- `TrafficSpawnPlanner` chooses the next traffic lane without repeating the last one.
- `ChaseLaneDecision` chooses the suspect vehicle target lane from blocked-lane state.
- `StarTiming` defines star thresholds and spawn phases.

## Testing

Run the repository checks locally:

```bash
python scripts/check_project.py
```

In Unity, open the project with Unity 2019.2.2f1 and run the edit-mode tests from the Test Runner:

- `LaneLayoutTests`
- `TrafficSpawnPlannerTests`
- `ChaseLaneDecisionTests`
- `StarTimingTests`

## Notes For Reviewers

The public version is intentionally trimmed to source and project files. To make a playable local scene, add scene objects that match the script lookups (`copcar`, `chasecar`, `road1` through `road20`, traffic prefabs, star, replay, roadblock, and clones) or connect the scripts to an existing scene with equivalent object names.

The code favors simple Unity-compatible C# and small extracted services over framework-heavy abstractions because the gameplay loop is real-time and object-driven.
