app.service('dbopService', function ($http) {


    //Create new
    this.post = function (TvShow) {
        var request = $http({
            method: "post",
            url: "/api/TVShowsAPI",
            data: TvShow
        });
        return request;
    }
    //Get Single 
    this.get = function (Id) {
        return $http.get("/api/TVShowsAPI/" + Id);
    }

    //Get All
    this.getTvShows = function () {
        return $http.get("/api/TVShowsAPI");
    }


    //Update  
    this.put = function (Id, TvShow) {
        var request = $http({
            method: "put",
            url: "/api/TVShowsAPI/" + Id,
            data: TvShow
        });
        return request;
    }
    //Delete  
    this.delete = function (Id) {
        var request = $http({
            method: "delete",
            url: "/api/TVShowsAPI/" + Id
        });
        return request;
    }
});