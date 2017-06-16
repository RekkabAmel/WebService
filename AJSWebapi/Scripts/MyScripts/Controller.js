
app.controller('DbopController', function ($scope, dbopService) {

    $scope.IsNew = 1; // Used to check if we update a tv show or add a new one

    getData();

    // Load all tv shows
    function getData() {
        var promiseGet = dbopService.getTvShows();

        promiseGet.then(function (t) {
            $scope.TvShows = t.data
        },
            function (errorT) {
                console.log('Chargement des séries tv impossible', errorT);
            });
    }

    // Load a single tv show
    $scope.get = function (ts) {
        var promiseGetSingle = dbopService.get(ts.Id);

        promiseGetSingle.then(function (t) {
            var res = t.data;
            $scope.Id = res.Id;
            $scope.Name = res.Name;
            $scope.Year = res.Year;
            $scope.Actors = res.Actors;
            $scope.IsNew = 0;
        },
        function (e) {
            console.log('Chargement des séries tv impossible', e);
        });
    }

    // Clear form
    $scope.clear = function () {
        $scope.IsNew = 1;
        $scope.Id = 0;
        $scope.Name = "";
        $scope.Year = 0;
        $scope.Actors = "";
    }

    // Delete tv show
    $scope.delete = function () {
        var promiseDelete = dbopService.delete($scope.Id);
        promiseDelete.then(function (t) {
            $scope.Message = "Série supprimée";
            $scope.Id = 0;
            $scope.Name = "";
            $scope.Year = 0;
            $scope.Actors = "";
            getData();
        }, function (err) {
            console.log("Error " + err);
        });
    }

    // Save tv show
    $scope.save = function () {
        var TvShow = {
            Id: $scope.Id,
            Name: $scope.Name,
            Year: $scope.Year,
            Actors: $scope.Actors
        };

        if ($scope.IsNew === 1) { //New tv show, insert
            var promisePost = dbopService.post(TvShow);
            promisePost.then(function (t) {
                $scope.Id = t.data.Id;
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        } else {   // Already exists tv show, update 
            var promisePut = dbopService.put($scope.Id, TvShow);
            promisePut.then(function (t) {
                $scope.Message = "Série mise à jours";
                getData();
            }, function (e) {
                console.log("Error " + e);
            });
        }
    };
});