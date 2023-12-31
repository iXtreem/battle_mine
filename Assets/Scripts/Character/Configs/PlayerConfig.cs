using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private AirborneStateConfig _airborneStateConfig;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private SlideWallStateConfig _slideWallStateConfig;

    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    public RunningStateConfig RunningStateConfig => _runningStateConfig;
    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public SlideWallStateConfig SlideWallStateConfig => _slideWallStateConfig;

}