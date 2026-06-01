# QA

## Automated Checks

The repository includes edit-mode tests for deterministic gameplay logic:

- Lane coordinate lookup and nearest-lane detection
- Traffic lane selection after the previous lane is known
- Suspect vehicle lane choice when preferred lanes are blocked
- Star timing thresholds and spawn phase selection

The local hygiene script validates required files, rejects Unity output folders, enforces size limits on split scripts, and scans runtime scripts for commented-out code.

```bash
python scripts/check_project.py
```

## Manual Smoke Test Checklist

Use Unity 2019.2.2f1 with a connected scene that provides the required object names.

1. Start a run and confirm the player and suspect vehicles move forward together.
2. Hold left and right controls and confirm the player stays inside the four-lane bounds.
3. Let traffic spawn and confirm lanes do not repeat consecutively.
4. Force a blocked suspect lane and confirm the suspect vehicle changes to an adjacent lane.
5. Wait for star timing thresholds and confirm stars move ahead of the suspect vehicle.
6. Collect a star and confirm the score state advances.
7. Hit an obstacle and confirm the replay control is shown.
8. Replay and confirm road positions, traffic objects, stars, movement state, and counters reset.

## Known Public-Repository Scope

The public repository does not include commercial art packages or a playable scene. Automated tests cover extracted gameplay rules, and manual scene QA requires adding compatible scene objects or reconnecting the scripts to a local scene.
