$here = Split-Path -Parent $MyInvocation.MyCommand.Path
. "$here\FootballSimulation.ps1"

# Requirements: In terms of input and probability distribution of results

function GetResultProbability {
    param ($resultProbabilities, $team1Goals, $team2Goals)
    foreach ($resultProbability in $resultProbabilities) {
        if ($resultProbability.Result.Team1Goals -eq $team1Goals -and $resultProbability.Result.Team2Goals -eq $team2Goals) {
            return $resultProbability
        }
    }
}

Describe "GetMatchPredictions" {
    It "Identical teams even distribution" {
        $prediction = GetMatchPrediction
        $probability1 = $prediction.Probability1
        $probabilityX = $prediction.ProbabilityX
        $probability2 = $prediction.Probability2
        $probability1.should.be($probability2)
        $probabilityX.should.be(100-$probability1-$probability2)
        $resultProbabilities = $prediction.ResultProbabilities
        $result10 = GetResultProbability $resultProbabilities 1 0
        Write-Host $result10.Result
        $result01 = GetResultProbability $resultProbabilities 0 1
        $result10.Probability.should.be($result01.Probability)
        
    }
}