import { IProduct } from './product';
export interface PaginationMember {
  itemPerPage: number;
  currentPage: number;
  totalItems: number;
  totalPages: IProduct[];
}
 export class PaginationResult<T> {

 result: T ;
 pagination :PaginationMember ;
 }
