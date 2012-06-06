function MatchResult {
    param ($team1Goals = 0, $team2Goals = 0)
    $matchResult = "" | Select Team1Goals,Team2Goals
    $matchResult.Team1Goals = $team1Goals
    $matchResult.Team2Goals = $team2Goals
    return $matchResult
}

function MatchPrediction {
    param ($probability1 = 33, $probabilityX = 34, $probability2 = 33)
    $matchPrediction = "" | Select Probability1,ProbabilityX,Probability2
    $matchPrediction.Probability1 = $probability1
    $matchPrediction.ProbabilityX = $probabilityX
    $matchPrediction.Probability2 = $probability2
    return $matchPrediction
}

function SimulateMatch {
    $pitchWidth = 7
    $pitchLength = 11
    $ballX = 4
    $ballY = 6
    $minutes = 0
    $timeStep = 1
    for ($minutes = 0; $minutes -le 90; $minutes += $timeStep) {
        #Write-Host "After $minutes minutes the ball is in area ($ballX, $ballY)."
    }
    
    return MatchResult
}

function GetMatchPrediction {
    $numberOfSimulations = 10
    $simulations = @()
    for ($simulationIndex = 0; $simulationIndex -le $numberOfSimulations; $simulationIndex++) {
        $simulations += SimulateMatch
    }
    
    return MatchPrediction
}

function RunMatch {
    cls
    $result = SimulateMatch
    $team1Goals = $result.Team1Goals
    $team2Goals = $result.Team2Goals
    "Result: $team1Goals-$team2Goals"
}