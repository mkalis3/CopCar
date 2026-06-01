# Architecture

CopCar is organized around Unity behaviours for scene interaction and plain C# services for deterministic rules.

## Runtime Behaviours

`MainScript` is split into partial files:

- `MainScriptLifecycle` initializes scene references, arrays, frame settings, and road segment positions.
- `MainScriptGameLoop` advances the player and suspect vehicles, spawns traffic, recycles road segments, and triggers star spawning.
- `MainScriptSpawning` chooses traffic lanes and positions traffic objects.
- `MainScriptLevelFlow` owns star placement, level thresholds, run ending, replay, and scoring.
- `MainScriptInput` handles left and right steering commands.

`ChaseCollision` is split into lifecycle and avoidance files. It reads blocked lanes from collisions, delegates the target-lane choice to `ChaseLaneDecision`, and applies smooth X-axis movement.

Small collision scripts keep scene responsibilities separate:

- `GameOver` ends the run for relevant crash collisions.
- `EndColl` ends the run at the finish trigger.
- `AddStars` updates scoring when the player collects a star.
- `StarColl` removes collected star objects.
- `ChaseCollision2` clears blocked-lane state after traffic has passed the suspect vehicle.

## Domain Services

`LaneLayout` centralizes the four lane IDs and X positions. This removes scattered magic numbers from movement and reset code.

`TrafficSpawnPlanner` keeps traffic placement deterministic and testable by mapping the previous lane and random choice to a valid next lane.

`ChaseLaneDecision` keeps blocked-lane decision rules outside Unity collision code.

`StarTiming` owns the thresholds that decide when the next star should appear and which spawn phase should run.

## Data Flow

1. `MainScriptGameLoop` advances the run each frame.
2. Traffic objects are created through `TrafficSpawnPlanner` and positioned with `LaneLayout`.
3. Collisions mark lanes as occupied in `ChaseCollision`.
4. `ChaseLaneDecision` selects the next suspect vehicle lane.
5. `StarTiming` gates collectible spawning based on elapsed run time and collected-star count.
6. Replay resets positions, counters, traffic state, road positions, and chase movement state.
