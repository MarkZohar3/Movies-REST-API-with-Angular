import { Component, OnInit } from '@angular/core';
import { Movie } from './models/movie.model';
import { MoviesService } from './service/movies.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit{
  title = 'Movies.Frontend';
  movies: Movie[] = [];
  movie: Movie = {
    id: '',
    title: '',
    minutesDuration: ''
  }

  constructor(private moviesService: MoviesService){
    
  }

  ngOnInit(): void {
    this.getAllMovies();
  }

  getAllMovies() {
    this.moviesService.getAllMovies()
    .subscribe(
      response => {
        this.movies = response;
      }
    );
  }

  submitMovie(){
      if(this.movie.id === ''){
        this.moviesService.addMovie(this.movie)
        .subscribe(
          response => {
            console.log(this.movie);
            
            //refresh the list
            this.getAllMovies();
            //clear input values
            this.movie = {
              id: '',
              title: '',
              minutesDuration: ''
            };
            
          }
          
        )

      }
      else {
        this.updateMovie(this.movie);
      }



  }

  deleteMovie(id: string){
    this.moviesService.deleteMovie(id)
    .subscribe(
      response => {
        this.getAllMovies();
      }
    )
  }

  populateForm(movie: Movie){
    this.movie = movie;
  }

  updateMovie(movie: Movie){
    this.moviesService.updateMovie(movie)
    .subscribe(response => {
      //refresh the list again
      this.getAllMovies();
    });
  }

}
