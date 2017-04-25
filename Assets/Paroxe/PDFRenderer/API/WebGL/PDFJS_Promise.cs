using System;

namespace Paroxe.PdfRenderer.WebGL
{
    public class PDFJS_Promise<T> : IPDFJS_Promise
    {
        private string m_PromiseHandle;
        private bool m_HasResult;
        private bool m_HasSucceeded;
        private bool m_HasFinished;
        private bool m_HasReceivedJSResponse;
        private bool m_HasBeenCancelled;
        private string m_ObjectHandle;
        private T m_Result;

        public string PromiseHandle
        {
            get { return m_PromiseHandle; }
        }

        public T Result
        {
            get { return m_Result; }
            set
            {
                m_Result = value;
            }
        }

        public string JSObjectHandle
        {
            get { return m_ObjectHandle; }
            set
            {
                if (value != m_ObjectHandle)
                {
                    m_ObjectHandle = value;
                }
            }
        }

        public bool HasSucceeded
        {
            get { return m_HasSucceeded; }
            set
            {
                if (value != m_HasSucceeded)
                {
                    m_HasSucceeded = value;
                }
            }
        }

        public bool HasFinished
        {
            get
            {
                return m_HasFinished;
            }
            set
            {
                if (value != m_HasFinished)
                {
                    m_HasFinished = value;
                }
            }
        }

        public bool HasReceivedJSResponse
        {
            get
            {
                return m_HasReceivedJSResponse;
            }
            set
            {
                if (value != m_HasReceivedJSResponse)
                {
                    m_HasReceivedJSResponse = value;
                }
            }
        }

        public bool HasBeenCancelled
        {
            get
            {
                return m_HasBeenCancelled;
            }
            set
            {
                m_HasBeenCancelled = value;
            }
        }

        public PDFJS_Promise()
        {
            m_PromiseHandle = CreateGUID();
        }

        private string CreateGUID()
        {
            return "{" + Guid.NewGuid().ToString() + "}";
        }
    }
}