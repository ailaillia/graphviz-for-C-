
//this file is used for creating Dynamic Link Library on windows Operating System

//the head file in the "include" directory of installed-graphviz
#include "..\include\graphviz\gvc.h"

extern Agdesc_t _Agdirected(void)
{
	return Agdirected;
}

extern GVC_t *_gvContext(void)
{
	return gvContext();
}

extern Agraph_t *_agopen(char *name, Agdesc_t desc, Agdisc_t * disc)
{
	return agopen(name, desc, disc);
}


extern Agnode_t *_agnode(Agraph_t * g, char *name, int createflag)
{
	return agnode(g,name,createflag);
}

extern Agedge_t *_agedge(Agraph_t * g, Agnode_t * t, Agnode_t * h, char *name, int createflag)
{
	return agedge(g,t,h,name,createflag);
}

extern int _agsafeset(void* obj, char* name, char* value, char* def)
{
	return agsafeset(obj, name, value, def);
}


extern int _gvLayout(GVC_t *gvc, graph_t *g, const char *engine)
{
	return gvLayout(gvc, g, engine);
}

extern int _gvRenderContext(GVC_t *gvc, graph_t *g, const char *format, void *context)
{
	return gvRenderContext(gvc, g, format, context);
}

extern int _gvRenderData(GVC_t *gvc, graph_t *g, const char *format, char **result, unsigned int *length)
{
	return gvRenderData(gvc, g, format, result, length);
}

extern void _gvFreeRenderData(char* data)
{
	gvFreeRenderData(data);
}

extern int _gvFreeLayout(GVC_t *gvc, graph_t *g)
{
	return gvFreeLayout(gvc, g);
}

extern int _agclose(Agraph_t * g)
{
	return agclose(g);
}

extern int _gvFreeContext(GVC_t *gvc)
{
	return gvFreeContext(gvc);
}

