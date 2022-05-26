export class PagedViewModel<T> {
  nome: string;
  list: Array<T>;
  pageIndex: number;
  pageSize: number;
  query: string;
  totalResults: number;
  totalPages: number;
}
