import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Movie } from '../models/movie.model';

@Injectable({
  providedIn: 'root'
})
export class MoviesService {

  baseUrl = 'https://localhost:7129/api/Movies'

  constructor(private http: HttpClient) { }

  //get all movies
  getAllMovies(): Observable<Movie[]> {
      return this.http.get<Movie[]>(this.baseUrl);
  }

  addMovie(movie: Movie): Observable<Movie> {
    movie.id = '00000000-0000-0000-0000-000000000000'
    return this.http.post<Movie>(this.baseUrl, movie);
  }

  deleteMovie(id:string): Observable<Movie>{
    return this.http.delete<Movie>(this.baseUrl + '/' +id);
  }


  updateMovie(movie:Movie): Observable<Movie>{
    return this.http.put<Movie>(this.baseUrl + '/' +movie.id, movie);
  }


}
