using System;

namespace API.Errors {
        public class ApiResponse {
            public int StatuesCode { get; set; }
            public string Message { get; }

            public ApiResponse (int statuesCode, string message = null) {
                StatuesCode = statuesCode;
                Message = message?? GetDatauflitMessageForStatusCode(StatuesCode);
            }

            private string GetDatauflitMessageForStatusCode(int statuesCode) {
                return statuesCode
                switch {

                      400 => "A bad request ,you have made ",
                        401 => "Authorizes ,you are not",
                        404 => "Resources found ,it was not",
                        500 => "Errors are the path to the dark side. Errors lead to anger . Anger lead to hate leads to career change",
                          _ => null
                };

            }
        }
        
        }