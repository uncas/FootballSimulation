function MatchResult {
    param ($team1Goals = 0, $team2Goals = 0)
    $this = "" | Select Team1Goals, Team2Goals
    $this.Team1Goals = $team1Goals
    $this.Team2Goals = $team2Goals
    return $this
}

function ResultProbability {
    param ($result, $probability)
    $this = "" | Select Result, Probability
    $this.Result = $result
    $this.Probability = $probability
    return $this
}

function MatchPrediction {
    param ($probability1 = 33, $probabilityX = 34, $probability2 = 33)
    $this = "" | Select Probability1, ProbabilityX, Probability2, ResultProbabilities
    $this.Probability1 = $probability1
    $this.ProbabilityX = $probabilityX
    $this.Probability2 = $probability2
    $this.ResultProbabilities = @()
    return $this
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
    
    $prediction = MatchPrediction
    $prediction.ResultProbabilities += ResultProbability (MatchResult 1 0) 0.1
    $prediction.ResultProbabilities += ResultProbability (MatchResult 0 1) 0.1
    return $prediction
}

function RunMatch {
    cls
    $result = SimulateMatch
    $team1Goals = $result.Team1Goals
    $team2Goals = $result.Team2Goals
    "Result: $team1Goals-$team2Goals"
}